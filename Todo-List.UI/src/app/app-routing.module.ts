import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {GoalistComponent} from "./components/goalist/goalist.component";

const routes: Routes = [
  {path:"", component: GoalistComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
