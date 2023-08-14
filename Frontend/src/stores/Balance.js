import { defineStore } from 'pinia'

export const useBalanceStore = defineStore('balance', {
    state: () => ({ balance: 0, bet: 0, isUserLoaded: false, user: ""  }),

    actions: {
      setBalance(amount) {
        this.balance = amount
      },
      setBet(amount) {
        this.bet = amount
      },
      setIsUserLoaded() {
        this.isUserLoaded = true
      },
      setUser(username) {
        this.user = username
      }
    },
})