<template>
    <div class="course-review-statistics">
		<p>{{reviewStatistic.reveiwCnt}} Reviews</p>
		<ul class="rating-container row">
			<li>
                <div class="column">
                    <strong>课程内容</strong>
                    <span class="rating" :class="getRate(reviewStatistic.content)">{{reviewStatistic.content}}</span>
                </div>
            </li>
			<li>
                <div class="column">
                    <strong>教学水平</strong>
                    <span class="rating" :class="getRate(reviewStatistic.teaching)">{{reviewStatistic.teaching}}</span>
                </div>    
            </li>
			<li>
                <div class="column">
                    <strong>评分情况</strong>
                    <span class="rating" :class="getRate(reviewStatistic.grading)">{{reviewStatistic.grading}}</span>
                </div>
            </li>
			<li>
                <div class="column">
                    <strong>课程作业</strong>
                    <span class="rating" :class="getRate(reviewStatistic.workload)">{{reviewStatistic.workload}}</span>
                </div>
            </li>
		</ul>
	</div>
</template>

<script>
export default {
    name:"CourseStatistic",
    props:{
        reviewStatistic:{
            type: Object,
            default: function(){
                return{
                    reveiwCnt:100,
                    content:"10",
                    teaching:"10",
                    grading:"10",
                    workload:"10",
                }
            }
        }
    },
    computed: {
        getRate(){
            return (grade) =>{
                grade = Number(grade)
                if(8 <= grade && grade <= 10){return "rating-5";}
                if(6 <= grade && grade < 8){return "rating-4";}
                if(4 <= grade && grade  < 6){return "rating-3";}
                if(2 <= grade && grade  < 4){return "rating-2";}
                if(0 <= grade && grade < 2){return "rating-1";}
            }
        },
    }
}
</script>

<style scoped>

.course-review-statistics{
    max-width:180px;
    height:400px;
}

.course-review-statistics .rating-container li { margin-bottom:10px}

.course-review-statistics .rating-container li .rating {
    width: 50px;
    font-size: 22px;
    line-height: 35px;
    border-radius: 6px;
    margin: 0 auto;
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
.rating-5 {background: #5a5;}


</style>