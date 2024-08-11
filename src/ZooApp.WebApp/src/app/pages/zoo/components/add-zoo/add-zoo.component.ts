import { Component, Input, OnInit } from "@angular/core";
import {FormGroup, FormControl, ReactiveFormsModule} from '@angular/forms';
import { ZooService } from "../../../../service/zoo";
import { ZooModel } from "../../../../model/zoo.model";
import { ZooComponent } from "../../zoo.component";

@Component({
  selector: 'add-zoo',
  standalone: true,
  templateUrl: './add-zoo.component.html',
  imports: [ZooComponent, ReactiveFormsModule] 
})
export class AddZooComponent implements OnInit {
  @Input() zooList: ZooModel[] = [];

  newZooForm = new FormGroup({
    name: new FormControl(''),
    address: new FormControl(''),
  });
  
  constructor(private zooService: ZooService) {}

  ngOnInit(): void {}
  
  addZoo(): void {
    const { name, address } = this.newZooForm.value;
    if(name && address) {
      this.zooService.addZoo({ name, address })
        .then(zoo => {
          if (zoo) {
            this.zooList.push(new ZooModel(zoo.name, zoo.address));
          }
        });
    }  
  }
}