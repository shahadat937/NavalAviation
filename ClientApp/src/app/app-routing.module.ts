import { Page404Component } from "./authentication/page404/page404.component";
import { AuthLayoutComponent } from "./layout/app-layout/auth-layout/auth-layout.component";
import { MainLayoutComponent } from "./layout/app-layout/main-layout/main-layout.component";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { AuthGuard } from "./core/guard/auth.guard";
import { Role } from "./core/models/role";
const routes: Routes = [
  {
    path: "",
    component: MainLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: "basic-setup",
        canActivate: [AuthGuard],
        data: {
          role: [Role.Admin, Role.SuperAdmin, Role.User],
        },
        loadChildren: () =>
          import("./basic-setup/basic-setup.module").then(
            (m) => m.BasicSetupModule
          ),
      },
      {
        path: "biodata",
        canActivate: [AuthGuard],
        data: {
          role: [Role.Admin, Role.SuperAdmin, Role.User,Role.CO,Role.HR],
         // role: [Role.Admin, Role.SuperAdmin, Role.User,Role.CO,Role.HR],
        },
        loadChildren: () =>
          import("./biodata/biodata.module").then((m) => m.BiodataModule),
      },

      {
        path: "spares-management",
        canActivate: [AuthGuard],
        data: {
          role: [Role.Admin, Role.SuperAdmin, Role.User, Role.CO],
        },
        loadChildren: () =>
          import("./spares-management/spares-management.module").then(
            (m) => m.SparesManagementModule
          ),
      },
      // {
      //   path: "password",
      //   canActivate: [AuthGuard],
      //   data: {
      //     role: [Role.Admin, Role.SuperAdmin, Role.User],
      //   },
      //   loadChildren: () =>
      //     import("./password/password.module").then((m) => m.PasswordModule),
      // },
      {
        path: 'password',
        canActivate: [AuthGuard],
        data: {
          role: [Role.FLGWG,Role.User,Role.Admin, Role.SuperAdmin,Role.CO,Role.HR],
        },
        loadChildren: () =>
          import('./password/password.module').then((m) => m.PasswordModule),
      },
      {
        path: 'barcode-management',
        canActivate: [AuthGuard],
        data: {
          role: [Role.User,Role.Admin, Role.SuperAdmin,Role.CO],
        },
        loadChildren: () =>
          import('./barcode-management/barcode-management.module').then((m) => m.BarcodeManagementModule),
      },
      {
        path: "tools-management",
        canActivate: [AuthGuard],
        data: {
          role: [Role.Admin, Role.SuperAdmin, Role.User, Role.CO],
        },
        loadChildren: () =>
          import("./tools-management/tools-management.module").then(
            (m) => m.ToolsManagementModule
          ),
      },
      {
        path: "issue-management",
        canActivate: [AuthGuard],
        data: {
          role: [Role.Admin, Role.SuperAdmin, Role.User],
        },
        loadChildren: () =>
          import("./issue-management/issue-management.module").then(
            (m) => m.IssueManagementModule
          ),
      },
      {
        path: "record-room",
        canActivate: [AuthGuard],
        data: {
          role: [Role.Admin, Role.SuperAdmin, Role.User, Role.CO, Role.EXO],
        },
        loadChildren: () =>
          import("./record-room/record-room.module").then(
            (m) => m.RecordRoomModule
          ),
      },
      {
        path: "about",
        canActivate: [AuthGuard],
        data: {
          role: [Role.Admin, Role.SuperAdmin, Role.User, Role.CO],
        },
        loadChildren: () =>
          import("./about/about.module").then(
            (m) => m.AboutModule
          ),
      },
      {
        path: "mea",
        canActivate: [AuthGuard],
        data: {
          role: [Role.Admin, Role.SuperAdmin, Role.User, Role.MEA, Role.CO],
        },
        loadChildren: () =>
          import("./mea/mea.module").then(
            (m) => m.MEAModule
          ),
      },
      {
        path: "maintenence-planning",
        canActivate: [AuthGuard],
        data: {
          role: [Role.Admin, Role.SuperAdmin, Role.User, Role.CO],
        },
        loadChildren: () =>
          import("./maintenence-planning/maintenence-planning.module").then(
            (m) => m.MaintenecePlanningModule
          ),
      },

      {
        path: "security",
        canActivate: [AuthGuard],
        data: {
          role: [Role.Admin, Role.SuperAdmin, Role.User],
        },
        loadChildren: () =>
          import("./security/security.module").then((m) => m.SecurityModule),
      },

      { path: "", redirectTo: "/authentication/signin", pathMatch: "full" },
      {
        path: "admin",
        canActivate: [AuthGuard],
        data: {
          role: [Role.FLGWG,Role.Admin, Role.SuperAdmin, Role.User, Role.CO, Role.MEA, Role.HR, Role.EXO],
        },
        loadChildren: () =>
          import("./admin/admin.module").then((m) => m.AdminModule),
      },

      // Extra components
      {
        path: "extra-pages",
        loadChildren: () =>
          import("./extra-pages/extra-pages.module").then(
            (m) => m.ExtraPagesModule
          ),
      },
    ],
  },
  {
    path: "authentication",
    component: AuthLayoutComponent,
    loadChildren: () =>
      import("./authentication/authentication.module").then(
        (m) => m.AuthenticationModule
      ),
  },
  { path: "**", component: Page404Component },
];
@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: "legacy" })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
