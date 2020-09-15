<template>
   <q-card class="white q-mt-xs"  >
        <div class="row justify-end">
            <div class="col-auto q-mx-md q-my-md">
                <q-avatar size="50px">
                    <img :src="headURL">
                </q-avatar>
            </div>
            <div class="col q-px-sm q-py-sm">
                <div class="row">
                    <div class="text-wrapper">
                      <a text-decoration: none href="#">{{nickName}}</a> :{{content}}
                      </div>
                </div>
            </div>
            <div class="col-auto q-px-sm q-py-sm">
                <q-btn class="q-mx-xs" color="white" @click="Reply" text-color="black" label="回复" />
            </div>
        </div>
    </q-card>
</template>

<script>
export default {
  name: 'Reply',
  props: {
    headURL: {
      type: String,
      default: 'https://cdn.quasar.dev/img/avatar.png'
    },
    nickName: {
      type: String,
      required: true
    },
    content: {
      type: String,
      default: ''
    }
  },
  methods: {
    Reply () {
      this.$emit('changeReplyPrefix', this.nickName)
    }
  }
}
</script>
