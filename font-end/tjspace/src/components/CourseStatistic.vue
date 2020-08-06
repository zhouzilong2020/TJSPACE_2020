<template>
  <div class="course-review-statistics">
		<p>{{courseStatistic.reveiwCnt}} Reviews</p>
		<ul class="rating-container">
			<li><strong>课程内容</strong><span class="rating" :class="getRate(courseStatistic.content)">{{courseStatistic.content}}</span></li>
			<li><strong>教学水平</strong><span class="rating" :class="getRate(courseStatistic.teaching)">{{courseStatistic.teaching}}</span></li>
			<li><strong>评分情况</strong><span class="rating" :class="getRate(courseStatistic.grading)">{{courseStatistic.grading}}</span></li>
			<li><strong>课程作业</strong><span class="rating" :class="getRate(courseStatistic.workload)">{{courseStatistic.workload}}</span></li>
		</ul>
	</div>
</template>

<script>
export default {
    name:"CourseStatistic",
    props:{
        courseStatistic:{
            type: Object,
            default: function(){
                return{
                    reveiwCnt:100,
                    content:"B",
                    teaching:"A",
                    grading:"A",
                    workload:"A",
                }
            }
        }
    },
    computed: {
        getRate(){
            return (grade) =>{
                switch(grade){
                    case "A": return "rating-4";
                    case "B": return "rating-3";
                    case "C": return "rating-2";
                    case "D": return "rating-1";
                }
            }
        },

    }
}
</script>

<style>

.course-review-statistics{
    width:250px;
    height:350px;
}

.course-review-statistics .rating-container li .rating {
    width: 50px;
    font-size: 22px;
    line-height: 35px;
    border-radius: 6px;
    margin: 0 10px;
}



.rating-container li .rating {
    display: inline-block;
    width: 20px;
    line-height: 20px;
    color: #fff;
    font-weight: 700;
    font-size: 12px;
    margin: 0;
    border-radius: 4px;
}

.course-review-statistics {
    padding: 14px 10px 8px;
    margin-bottom: 12px;
    border: 1px solid #ddd;
    border-radius: 8px;
    overflow: hidden;
    background: #fafafa;
}

.course-review-statistics > p {
    text-align: center;
    font-size: 24px;
    font-weight: 700;
    color: #036;
    margin-bottom: 5px;
    line-height: 34px;
}

.course-review-statistics .rating-container {
    width: 100%;
    text-align: center;
}

.course-review-statistics .rating-container li {
    position: relative;
    width: 100%; 
    height: 70px;
}

.rating-container {
    padding: 0;
    overflow: hidden;
}

.rating-1 {background: #fb1420;}
.rating-2 {background: #ff7800;}
.rating-3 {background: #ffba00;}
.rating-4 {background: #afc732;}


</style>