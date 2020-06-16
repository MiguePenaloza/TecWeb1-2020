import { TodoService } from './../../services/todo.service';
import { Component, OnInit } from '@angular/core';
import { Todo } from 'src/app/models/Todo';

@Component({
  selector: 'app-todos',
  templateUrl: './todos.component.html',
  styleUrls: ['./todos.component.css']
})
export class TodosComponent implements OnInit {

  todosList :Todo[]
  constructor(private todoService: TodoService) { }

  ngOnInit(): void {
    this.todoService.getTodos().subscribe( todos => {
      this.todosList = todos;
    });
  }

  deleteTodo(todoToDelete:Todo): void {
    this.todosList = this.todosList.filter(t => t.id != todoToDelete.id);
    //delete from backend
    this.todoService.deleteTodo(todoToDelete).subscribe( r => {
      console.log(r);
    })
  }

  addTodoAndSend(todoToAdd:Todo) {
    this.todoService.addTodo(todoToAdd).subscribe( t => {
      this.todosList.push(t);
    });
  }
}
