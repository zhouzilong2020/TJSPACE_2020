import CourseInfo from "@/page/CourseInfo"
import BBSHomePage from "@/page/BBSHomePage"


export default {
    mode:"history",
    routes: [
        {
            path: "/a",
            component: CourseInfo,
        },{
            path: "/b",
            component: BBSHomePage,
        }
    ],
}