import { Component, OnInit, HostListener } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {


  constructor() { }

  ngOnInit(): void {
  }

  @HostListener("window:scroll", ['$event'])


  doSomethingOnInternalScroll($event: Event) {
    // do some stuff here when the window is scrolled
    const verticalOffset = window.pageYOffset
      || document.documentElement.scrollTop
      || document.body.scrollTop || 0;
    console.log(verticalOffset);

    if (document.body.scrollTop > 80 || document.documentElement.scrollTop > 80) {
      //document.getElementById("navbar").style.padding = "30px 10px";
      document.getElementById("navbar").style.background = "rgb(0,0,0,0.8)";
      //document.getElementById("navbar").style.background = "transparent";
      document.getElementById("logo").style.fontSize = "25px";
    } else {
      //document.getElementById("navbar").style.padding = "80px 10px";
      document.getElementById("navbar").style.background = "#000000";
      document.getElementById("logo").style.fontSize = "35px";
    }
  }
}
