import { Component } from '@angular/core';
import { AuthService } from '../services/login.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  constructor(private dataService: AuthService) { }

  username: string = '';
  password: string = '';

  onSubmit() {

    const dataToSend = { username: this.username, password: this.password};

    this.dataService.login(dataToSend).subscribe(
      response => {
        console.log('POST request successful:', response);
        const token = (response as {token: string}).token
        alert("Login successful")
        localStorage.setItem('JWT', token);
      },
      error => {
        console.error('Error in POST request:', error);
        // Handle errors
      }
    );

    console.log('Submitted: Username - ' + this.username + ', Password - ' + this.password);
  }
}
