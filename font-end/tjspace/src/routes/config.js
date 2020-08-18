export default {
    routes: [
        {
            path: "/courseInfo/:courseid",
            component: ()=> import("@/page/CourseInfo"),
        },{
            path: "/BBSHomepage",
            component: ()=> import("@/page/BBSHomePage"),
        },{
            path: "/Forum",
            component: ()=> import("@/page/Forum"),
        },{
            path: "/SearchCourse",
            component: ()=> import("@/page/SearchCourse"),
        },{
            path: "/Homepage/:userid",
            component: ()=> import("@/page/Homepage"),
        },{
            path: "/Homepage/:userid/edit",
            component: ()=> import("@/page/SelfInfoModify"),
        },{
            path: "/makecomment/:userid/:courseid",
            component: ()=> import("@/page/MakeComment"),
        },{
            path: "*",  //表示匹配所有路径
            component: ()=> import("@/page/Error404"),
        }
    ],
    mode:"history",
}