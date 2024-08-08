import { Component, OnInit } from "@angular/core";
import { EnvironmentService } from "../../service/environment/environment.service";

@Component({
    standalone: true,
    selector: 'app-environment',
    templateUrl: './environment.component.html'
})
export class EnvironmentComponent implements OnInit {
    environment: string = '';
    baseUrlApi: string = '';
    
    constructor(private environmentService: EnvironmentService) {}

    ngOnInit(): void {
        const isProduction = this.environmentService.getIsProduction();
        if(isProduction){
            this.environment = 'Produção';
        }else{
            this.environment = 'Desenvolvimento';
        }
        
        this.baseUrlApi = this.environmentService.getApiBaseUrl();
    }
}