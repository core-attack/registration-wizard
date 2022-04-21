import { Component } from '@angular/core';

@Component({
  selector: 'app-counter-component',
  templateUrl: './registration-step1.component.html'
})
export class RegistrationStep1Component {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount += 6;
  }
}
