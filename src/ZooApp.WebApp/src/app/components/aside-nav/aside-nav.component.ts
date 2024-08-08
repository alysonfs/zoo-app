import { Component } from '@angular/core';
import { EnvironmentComponent } from '../environment/environment.component';

@Component({
  selector: 'app-aside-nav',
  standalone: true,
  imports: [EnvironmentComponent],
  templateUrl: './aside-nav.component.html'
})
export class AsideNavComponent {

}
