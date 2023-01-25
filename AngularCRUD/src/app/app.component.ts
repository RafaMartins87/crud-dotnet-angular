import { Component, OnInit } from '@angular/core';
import { ApiserviceService } from 'src/app/apiservice.service';
import { FormBuilder,FormGroup, FormControl } from '@angular/forms';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  constructor(private service: ApiserviceService, private formBuilder: FormBuilder) { }
  title = 'AngularCRUD';

  costList: any = [];
  costTypeList: any = [];

  weekDayId ="";
  weekDayDescription ="";
  costTypeId ="";
  costTypeDescription ="";
  valueSpentDateTime ="";
  valueSpentId ="1";
  valueSpentDescription="";
  insertUpdateDateTime ="";
  selectedCodeTypeDescription="";

	onSelect(ct:any): void {
    this.costTypeId= ct.id;
		this.selectedCodeTypeDescription = ct.name;
	}  

  ngOnInit(): void {
    this.GenerateDateWeek();
    this.LoadTable();
    this.LoadCostTypeListMock();
  }

  checkoutForm = new FormGroup({
    costTypeId: new FormControl(''),
    valueSpentDescription: new FormControl(''),
  });

  AddCost() {    
    let requestObject = {
      costTypeId: this.costTypeId,
      CostTypeDescription:this.selectedCodeTypeDescription,
      weekDayId: 1,
      WeekDayDescription:"1",
      ValueSpentDateTime:this.GenerateDateTimeNow(),
      ValueSpentId:this.RandomNumber(),
      ValueSpentDescription:this.checkoutForm.value.valueSpentDescription,
      InsertUpdateDateTime:this.GenerateDateTimeNow() 
    };

    this.service.addGeneralCost(requestObject).subscribe(res => {
      alert(res.toString());
    });
  }

  GenerateDecimalValueSpent(value: string){
    let decimalNumber = parseFloat(value).toFixed(2);
    console.log('GenerateDecimalValueSpent ', decimalNumber);
  }

  GenerateCostTypeDescription(ctValue: string){
    if(ctValue){
      switch(ctValue){
        case "0":
          return 'contratou serviço';
        case "1":
          return 'contratou serviço';
        default:
          return 'xx';
      }   
    }else{
      return 'erro';
    }
  }

  RandomNumber(){
    let random = Math.floor(Math.random()*1000+1);
    console.log('RandomNumber ', random);
    return random;
  }

  GenerateDateWeek(){
    let dateTime = new Date();
    let timezoneOffset = dateTime.getTimezoneOffset()
    const weekDay = dateTime.getDay();
    let weekDay2 = dateTime.getUTCDate();
    console.log('GenerateDateWeek getTimezoneOffset ',timezoneOffset);
    console.log('GenerateDateWeek getDay ',weekDay);
    console.log('GenerateDateWeek getUTCDate',weekDay2);
    return dateTime.getDay();
  }

  GenerateDateTimeNow(){
    return new Date();

  }

  GenerateDateTimeHoursNow(){
    let dateTime = new Date();
    return dateTime.getHours();

  }

  LoadTable(){
    this.service.getGeneralCostList().subscribe(data=>{
      this.costList=data;
    })
  }

  LoadTableMock(){
    this.costList=[
      {
        "Valor":"1.2",
        "Tipo":"1",
        "DataGasto":"10/10/2022"
      },
      {
        "Valor":"1.2",
        "Tipo":"1",
        "DataGasto":"10/10/2022"
      },
    ]
  }

  LoadCostTypeListMock(){
    this.costTypeList=[
      {
        "id":"0",
        "description":"compra"
      },
      {
        "id":"1",
        "description":"serviço"
      }
    ]
  }

  GetCostTypeListMock(){
    return this.costTypeList=[
      {
        "id":"0",
        "description":"compra"
      },
      {
        "id":"1",
        "description":"serviço"
      }
    ]
  }
}