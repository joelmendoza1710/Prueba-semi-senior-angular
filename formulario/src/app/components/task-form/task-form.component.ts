import { Component, Inject } from '@angular/core';
import { TaskService } from '../../services/task.service';
import { Task } from '../../models/task.model';
import {
  FormControl,
  FormsModule,
  ReactiveFormsModule,
  UntypedFormBuilder,
  UntypedFormGroup,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-task-form',
  templateUrl: './task-form.component.html',
  styleUrls: ['./task-form.component.css'],
  imports: [FormsModule, ReactiveFormsModule,CommonModule],
})
export class TaskFormComponent {
  title = '';
  description = '';

  constructor(@Inject(TaskService) private taskService: TaskService) {}

  addTask(): void {
    if (!this.title.trim() || !this.description.trim()) {
      alert('El título y la descripción son obligatorios');
      return;
    }

    const newTask: Task = {
      id: 0, // La API asignará un ID automáticamente
      title: this.title,
      description: this.description,
      completed: false
    };

    this.taskService.addTask(newTask).subscribe(() => {
      window.location.reload(); // Recargar la página para actualizar la lista de tareas
    });

    this.title = '';
    this.description = '';
  }
}
