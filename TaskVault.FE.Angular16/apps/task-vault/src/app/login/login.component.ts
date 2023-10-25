import { Component } from '@angular/core';
import { AuthService } from '../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  loginSuccess: boolean | null = null;

  get JWT(): string {
    return localStorage.getItem('JWT') ?? '';
  }

  constructor(private dataService: AuthService) {}

  username: string = '';
  password: string = '';

  ngOnInit() {
    this.dataService.onLogin().subscribe((loginSuccess) => {
      this.loginSuccess = loginSuccess;
    });
  }

  onSubmit() {
    const dataToSend = { username: this.username, password: this.password };

    this.dataService.login(dataToSend).subscribe(
      (response) => {
        if (response) {
          const token = (response as { token: string }).token;
          console.log('token', token);
          localStorage.setItem('JWT', token);
        }
      },
      (error) => {
        console.error('Error in POST request:', error);
        alert(error.error);
        // Handle errors
        this.dataService.logout();
        localStorage.removeItem('JWT');
      }
    );

    console.log(
      'Submitted: Username - ' + this.username + ', Password - ' + this.password
    );
  }

  logout() {
    console.log('logged out');
    this.dataService.logout();
    localStorage.removeItem('JWT');
  }
}
