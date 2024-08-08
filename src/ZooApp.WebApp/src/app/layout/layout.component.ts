import { Component } from '@angular/core';
import { HeaderComponent, AsideNavComponent } from '../components';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [HeaderComponent, AsideNavComponent],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent {
  constructor() {
    console.log('LayoutComponent constructor');
  }
}
