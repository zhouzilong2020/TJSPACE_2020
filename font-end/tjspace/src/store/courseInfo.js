/**
 * 课程信息的数据仓库
 */
export default {
    namespaced: true,
    state: {
        courseInfo: null,
        isLoading: false,
        
    },
    mutations: {
      setCourseInfo(state, payload) {
        state.courseInfo = payload
      }
    },
}
