import { Component, OnInit, HostListener } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Login } from 'src/app/models/authentication/Login';
import { StoreService } from 'src/app/services/store.service';
import { InstrumentService } from 'src/app/services/instrument.service';
import { CreateAccount } from 'src/app/models/authentication/CreateAccount';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  login :Login;
  createUser :CreateAccount;
  isLogged :boolean = false;

  constructor(private authService: AuthenticationService, private storeService :StoreService, private instrumentService :InstrumentService) {
    this.login = new Login();
    this.login.email = '';
    this.login.password = '';
    this.createUser = new CreateAccount();
    this.createUser.email = '';
    this.createUser.password = '';
    this.createUser.confirmPassword = '';
  }

  ngOnInit(): void {
  }

  @HostListener("window:scroll", ['$event'])


  doSomethingOnInternalScroll($event: Event) {
    // do some stuff here when the window is scrolled
    // const verticalOffset = window.pageYOffset
    //   || document.documentElement.scrollTop
    //   || document.body.scrollTop || 0;
    // console.log(verticalOffset);

    if (document.body.scrollTop > 80 || document.documentElement.scrollTop > 80) {
      //document.getElementById("navbar").style.padding = "30px 10px";
      document.getElementById("navbar").style.background = "rgb(0,0,0,0.8)";
      //document.getElementById("navbar").style.background = "transparent";
      //document.getElementById("logo").style.fontSize = "25px";
    } else {
      //document.getElementById("navbar").style.padding = "80px 10px";
      document.getElementById("navbar").style.background = "#000000";
      //document.getElementById("logo").style.fontSize = "35px";
    }
  }

  vallidateEmailPassword(login: Login) :boolean{
    if ((login.email.includes('@') && login.email.length > 0) && (login.password.length > 4)) {
      document.getElementById("resMessage").innerHTML = '';
      return true;
    } else if (login.email.length < 2) {
        document.getElementById("resMessage").innerHTML = '<h6>Please enter a valid Email!</h6>';
        document.getElementById("resMessage").setAttribute("class", "badge badge-danger");
        return false;
      } else if (login.password.length < 5) {
          document.getElementById("resMessage").innerHTML = '<h6>The Password must have at least 5 characters!</h6>';
          document.getElementById("resMessage").setAttribute("class", "badge badge-danger");
          return false;
        }
  }

  onLogin(login: Login) {
    if (this.vallidateEmailPassword(login)) {
      this.authService.login(login).subscribe(r => {
        this.isLogged = r.isSuccess;
        document.getElementById("resMessage").innerHTML = "<h6>Signed in Successfully!!</h6>";
        document.getElementById("resMessage").setAttribute("class", "badge badge-success");
        this.storeService.setJWT(r.message);
        this.instrumentService.setJWT(r.message);
      }, (error) => {
        if (error.status == 400) {
          document.getElementById("resMessage").innerHTML = `<h6>${error.error.message}!!</h6>`;
          document.getElementById("resMessage").setAttribute("class", "badge badge-danger");
        }
      })
    }
  }

  onLogout() {
    this.isLogged = false;
    this.login.email = '';
    this.login.password = '';
    this.storeService.setJWT('');
    this.instrumentService.setJWT('');
    this.createUser.email = '';
    this.createUser.password = '';
    this.createUser.confirmPassword = '';
    document.getElementById("resMessage").innerHTML = '';
    document.getElementById("resCreateMessage").innerHTML = '';
    document.getElementById("resErrorsCreateMessage").innerHTML = '';
  }

  vallidateEmailPasswordConfirmPassword(newUser: CreateAccount) :boolean{
    if ((newUser.email.includes('@') && newUser.email.length > 2) && (newUser.password.length > 4) && (newUser.confirmPassword.length > 4)) {
      document.getElementById("resCreateMessage").innerHTML = "";
      return true;
    } else if (newUser.email.length < 2) {
        document.getElementById("resCreateMessage").innerHTML = '<h6>Please enter a valid Email!</h6>';
        document.getElementById("resCreateMessage").setAttribute("class", "badge badge-danger");
        return false;
      } else if (newUser.password.length < 5 || newUser.confirmPassword.length < 5) {
          document.getElementById("resCreateMessage").innerHTML = '<h6>The Password must have at least 5 characters!</h6>';
          document.getElementById("resCreateMessage").setAttribute("class", "badge badge-danger");
          return false;
        }
  }

  onCreateAccount(newUser :CreateAccount) {
    if (this.vallidateEmailPasswordConfirmPassword(newUser)) {
      this.authService.registerUser(newUser).subscribe( r => {
        document.getElementById("resCreateMessage").innerHTML = `<h6>${r.message}!!</h6>`;
        document.getElementById("resCreateMessage").setAttribute("class", "badge badge-success");
        document.getElementById("resErrorsCreateMessage").innerHTML = "";
      }, (error) => {
        if (error.status == 400) {
          document.getElementById("resCreateMessage").innerHTML = `<h6>${error.error.message}!!</h6>`;
          document.getElementById("resCreateMessage").setAttribute("class", "badge badge-danger");
          console.log(error.error.errors);
          document.getElementById("resErrorsCreateMessage").innerHTML = `${error.error.errors}`;
        }
      })
    }
  }
}
