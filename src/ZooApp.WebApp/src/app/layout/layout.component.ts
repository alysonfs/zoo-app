import { Component } from '@angular/core';
import { HeaderComponent } from '../pages/header/header.component';
import { AsideNavComponent } from '../pages/aside-nav/aside-nav.component';

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
