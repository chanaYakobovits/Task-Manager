import { NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-user',
  imports: [ReactiveFormsModule,MatFormFieldModule,MatInputModule, MatSelectModule,MatButtonModule,NgIf,MatIconModule],
  templateUrl: './user.html',
  styleUrl: './user.css'
})
export class User {
  userForm!: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.userForm = this.fb.group({
      UserName: ['', Validators.required],
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      Phone: ['', Validators.required],
      password: ['', Validators.required],
      Address: ['', Validators.required]
    });
  }
save(){
  console.log(this.userForm);
  
}
}
