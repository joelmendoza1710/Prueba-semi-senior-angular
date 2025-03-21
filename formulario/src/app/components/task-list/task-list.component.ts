import { Component, Inject, OnInit } from '@angular/core';
import { TaskService } from '../../services/task.service';
import { Task } from '../../models/task.model';
import { CommonModule } from '@angular/common';



@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css'],
  imports: [CommonModule]
})
export class TaskListComponent implements OnInit {
  tasks: Task[] = [];

  constructor(@Inject(TaskService) private taskService: TaskService) {}

  ngOnInit(): void {
    this.loadTasks();
  }

  loadTasks(): void {
    this.taskService.getTasks().subscribe(
      (tasks) => (this.tasks = tasks),
      (error) => console.error('Error al obtener tareas', error)
    );
  }

  toggleComplete(task: Task): void {
    const updatedTask = { ...task, completed: !task.completed };
    this.taskService.updateTask(task.id, updatedTask).subscribe(() => {
      this.loadTasks(); // Recargar tareas después de actualizar
    });
  }

  deleteTask(id: number): void {
    this.taskService.deleteTask(id).subscribe(() => {
      this.loadTasks(); // Recargar tareas después de eliminar
    });
  }
}
