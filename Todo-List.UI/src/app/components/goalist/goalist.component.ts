import { Component, OnInit } from '@angular/core';
import {Goals} from "../../modules/Goal";
import {GoalService} from "../../services/goal.service";

@Component({
  selector: 'app-goalist',
  templateUrl: './goalist.component.html',
  styleUrls: ['./goalist.component.scss']
})
export class GoalistComponent implements OnInit {

  goals: Goals[] = [];
  constructor(private service: GoalService) { }

  ngOnInit(): void {
    this.service.getGoals().subscribe({
      next: (res: Goals[]) => {
        this.goals = res;
      },
      error: (err) => {
        alert(err.error.message);
      }
    })
  }
  setIsDone(id: number,value: boolean){
    var goal = this.goals.find(x => x.id == id);
    goal!.isDone = !value;
    console.log(id);
    this.service.setIsDone(id, goal!.isDone).subscribe(
      {next: (res) => {
        console.log("success")
        },
      error: (err) => {
        console.log(err);
      }}
    );
  }
  addNewGoal(aim: string){
    let goal: Goals= {isDone: false, aim: aim, id: 0};
    this.service.addGoal(goal).subscribe({
      next: (res) => {
        this.ngOnInit();
    },
      error: (err) => {
        console.log(err.error.message);
      }
    });
  }
  deleteGoal(id: number){
    this.service.deleteGoal(id).subscribe({
      next: (res) => {
        this.ngOnInit();
      },
      error: (err) => {
        console.log(err.error.message);
      }
      });
  }
}
