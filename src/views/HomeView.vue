<template>
  <div id="app">

    <div v-if="isLoading">Loading ......</div>
    <div v-else>
      <div v-for="item in getItemsList" :key="item.id">
        {{ item.HomePhoneNumber }} - {{ item.PhoneNumber }} - {{ item.Birthday }} - {{ item.name }}
        <button @click="deleteItem(item.id)">Delete</button>
      </div>
      <br>

      <div>
        <div>
          HomePhoneNumber
          <input v-model="friend.HomePhoneNumber" type="text" />
        </div>
        <div>
          PhoneNumber
          <input v-model="friend.PhoneNumber" type="number" />
        </div>
        <div>
            Name
            <input v-model="friend.name" type="number" />
          </div>
        <div>
          Birthday
          <input v-model="friend.Birthday" type="text" />
        </div>
        <button @click="addItem(friend)">Add</button>
      </div>

      <hr />
    </div>

    <router-view />
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'
export default {
  components: {
    
  },
  name: 'HomeView',
  data() {
    return {
      friend: {},
    }
  },
  computed: {
    ...mapGetters('friend', ['getItemsList', 'isLoading']),
  },
  created() {
    this.loadList()
  },
  methods: {
    ...mapActions('friend', ['loadList', 'addItem', 'deleteItem', 'updateItem', 'loadFilteredData']),

  },
};
</script>
