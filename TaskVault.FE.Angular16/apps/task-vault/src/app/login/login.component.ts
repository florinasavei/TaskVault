import { Component } from '@angular/core';
import { AuthService } from '../services/login.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  loginSuccess: boolean | null = null;
  JWT: string = "";

  constructor(private dataService: AuthService) { }

  username: string = '';
  password: string = '';

  ngOnInit() {
    this.dataService.onLogin().subscribe((loginSuccess) => {
      this.loginSuccess = loginSuccess;
    });
    this.JWT = localStorage.getItem('JWT') ?? ""
  }

  onSubmit() {
    const dataToSend = { username: this.username, password: this.password};

    this.dataService.login(dataToSend).subscribe(
      response => {
        console.log('POST request successful:', response);
        const token = (response as {token: string}).token
        alert("Login successful")
        localStorage.setItem('JWT', token);
        this.JWT = token;
      },
      error => {
        console.error('Error in POST request:', error);
        alert(error)
        // Handle errors
        this.dataService.logout()
        localStorage.removeItem("JWT");
        this.JWT = "";
      }
    );

    console.log('Submitted: Username - ' + this.username + ', Password - ' + this.password);
  }
}
