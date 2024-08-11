import { Component, OnInit } from '@angular/core';
import { ZooService } from '../../../service/zoo';
import { ActivatedRoute } from '@angular/router';
import { ZooModel } from '../../../model/zoo.model';
import { AnimalModel } from '../../../model/animal.model';

@Component({
  selector: 'zoo-details',
  standalone: true,
  imports: [],
  templateUrl: './zoo-details.component.html'
})
export class ZooDetailsComponent implements OnInit{

  zooIdParam: string = '';
  
  zoo: ZooModel = new ZooModel('', '');

  animals: AnimalModel[] = [];
  
  constructor(private route: ActivatedRoute, private zooService: ZooService) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.zooIdParam = params['id'];
    });

    this.zooService.getZoo(this.zooIdParam)
      .then(zoo => {
        this.zoo = new ZooModel(zoo.name, zoo.address);
        this.zoo.uuid = zoo.uuid;
        this.zoo.animalCount = zoo.animalCount;
        this.zoo.guestCount = zoo.guestCount;
      });

    
  }
}
