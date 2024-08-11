import { Component } from '@angular/core';
import { ZooService } from '../../service/zoo';
import { ZooModel } from '../../model/zoo.model';
import { AddZooComponent } from './components/add-zoo/add-zoo.component';

@Component({
  selector: 'app-zoo',
  standalone: true,
  imports: [AddZooComponent],
  templateUrl: './zoo.component.html',
  styleUrl: './zoo.component.css'
})
export class ZooComponent {
  constructor(private zooService: ZooService) {}

  public zooList: ZooModel[] = [];

  ngOnInit(): void {
    this.zooService.getZooList()
      .then(data => this.zooList = data.map(zoo => {
        const zooData = new ZooModel(zoo.name, zoo.address);
        zooData.uuid = zoo.uuid;
        zooData.animalCount = zoo.animalCount;
        zooData.guestCount = zoo.guestCount;
        return zooData;
      }));
  }
}
