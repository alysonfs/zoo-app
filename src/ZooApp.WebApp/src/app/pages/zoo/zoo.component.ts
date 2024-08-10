import { Component } from '@angular/core';
import { ZooService } from '../../service/zoo';
import { ZooModel } from '../../model/zoo.model';

@Component({
  selector: 'app-zoo',
  standalone: true,
  imports: [],
  templateUrl: './zoo.component.html',
  styleUrl: './zoo.component.css'
})
export class ZooComponent {
  constructor(private zooService: ZooService) {}

  public zooList: ZooModel[] = [];

  addZoo(name: string, address: string): void {
    this.zooService.addZoo({ name, address })
      .then(zoo => {
        if (zoo) {
          this.zooList.push(new ZooModel(zoo.name, zoo.address));
        }
      });
  }

  ngOnInit(): void {
    this.zooService.getZooList()
      .then(data => this.zooList = data.map(zoo => new ZooModel(zoo.name, zoo.address)));
  }
}
