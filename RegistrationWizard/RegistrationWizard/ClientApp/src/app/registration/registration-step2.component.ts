import { Component } from '@angular/core';

@Component({
  selector: 'app-counter-component',
  templateUrl: './registration-step2.component.html'
})
export class RegistrationStep2Component {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount += 7;
  }
}
