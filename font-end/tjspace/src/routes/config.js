export default {
    routes: [
        {
            path: "/CourseInfo",
            component: () => import("@/pages/CourseInfo"),
        }, {
            path: "/login",
            name: "login",
            component: () => import("@/pages/Login"),
        }, {
            path: "/register",
            name: "register",
            component: () => import("@/pages/Reg"),
        }, {
            path: "/BBSHomepage",
            name: "BBSHomepage",
            component: () => import("@/pages/BBSHomePage"),
        }, {
            path: "/Forum",
            name: "Forum",
            component: () => import("@/pages/Forum"),
        }, {
            path: "/SearchCourse",
            name: "SearchCourse",
            component: () => import("@/pages/SearchCourse"),
        }, {
            path: "/Homepage/:userId",
            name: "Homepage",
            component: () => import("@/pages/Homepage"),
        }, {
            path: "/SelfInfoModify/:userid",
            name:'SelfInfoModify',
            component: () => import("@/pages/SelfInfoModify"),
        }, {
            path: "/makecomment/:userid/:courseid",
            component: () => import("@/pages/MakeComment"),
        }, {
            path: "/",  //表示匹配所有路径
            name: 'index',
            component: () => import("@/pages/index"),
        }, {
            path: "*",  //表示匹配所有路径
            component: () => import("@/pages/Error404"),
        }
    ],
    mode: "history",
}