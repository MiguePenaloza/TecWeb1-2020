import { TodoService } from './../../services/todo.service';
import { Todo } from 'src/app/models/Todo';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-todo',
  templateUrl: './edit-todo.component.html',
  styleUrls: ['./edit-todo.component.css']
})
export class EditTodoComponent implements OnInit {

  todo:Todo;
  checked:Boolean;

  constructor(private todoService:TodoService, private route:ActivatedRoute) {
    this.todo = new Todo();
   }

  ngOnInit(): void {
    const todoId = this.route.snapshot.paramMap.get("todoId");
    this.todoService.getTodo(todoId).subscribe(t => {
      this.todo = t;
    })
  }

  onChange(todo:Todo) {
    todo.completed = !todo.completed;
  }

  onSubmit(todo:Todo) {
    this.todoService.updateTodo(todo).subscribe(t => {
      console.log(t);
    });
  }

}
