import { TodoService } from './../../services/todo.service';
import { Todo } from './../../models/Todo';
import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-todo-item',
  templateUrl: './todo-item.component.html',
  styleUrls: ['./todo-item.component.css']
})
export class TodoItemComponent implements OnInit {

  @Input() todoInput: Todo
  @Output() todoDeleteOutput: EventEmitter<Todo> = new EventEmitter();
  constructor(private todoService:TodoService, private router:Router) { }

  ngOnInit(): void {
  }

  setClasses() {
    let classes = {
      todo: true,
      "is-complete": this.todoInput.completed
    }
    return classes;
  }

  onDelete() {
    this.todoDeleteOutput.emit(this.todoInput);
  }

  onChange() {
    this.todoInput.completed = !this.todoInput.completed;
    this.todoService.updateTodo(this.todoInput).subscribe( todo => {
      console.log(todo);
    })
  }

  onEdit(todo:Todo) {
    this.router.navigateByUrl(`/todos/${todo.id}`);
  }

}
