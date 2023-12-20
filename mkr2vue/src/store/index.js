import { createStore } from 'vuex'
import friend from './modules/friend.js'

export default createStore({
  namespaced: true,
  modules: {
    friend,
  }
})
