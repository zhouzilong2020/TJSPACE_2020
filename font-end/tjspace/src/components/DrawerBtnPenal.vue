<template>
        <div class="drwaer-option q-gutter-y-md" style="max-width: 310px">
            <q-tabs
                v-model="tab"
                indicator-color="primary"
                active-bg-color="primary"
                horizontal
                dense
            >
                <ul class="drawer-option-list">
                    <li>
                        <div class="row">
                            <q-tab class="text-purple" name="mails" icon="mail" label="Mails" />
                            <q-tab class="text-orange" name="alarms" icon="alarm" label="Alarms" />
                            <q-tab class="text-teal" name="movies" icon="movie" label="Movies" />
                        </div>
                    </li>
                    <li>
                        <div class="row">
                            <q-tab class="text-purple" name="mails" icon="mail" label="Mails" />
                            <q-tab class="text-orange" name="alarms" icon="alarm" label="Alarms" />
                            <q-tab class="text-teal" name="movies" icon="movie" label="Movies" />
                        </div>
                    </li>
                    

                </ul>
            </q-tabs>
        </div>

</template>

<script>
export default {
    data:()=> {
        return{
            depts:[],
                
        }
    }

}
</script>

<style>
.drwaer-option ul{list-style-type: none;}

</style>
