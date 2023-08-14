<script setup>
import { ref } from 'vue'
import { useBalanceStore } from "../stores/Balance";
import { useRouter } from "vue-router";
import axios from "axios";

const playerName = ref("");
const isSearching = ref(false)

const store = useBalanceStore();

const router = useRouter();
const data = ref({
  balance: null,
  bet: null,
});

const handleSearch = async() => {
  if( !playerName.value.trim() ) {
    return
  }
  isSearching.value = true
  try {
    const resp = await axios.get(`https:localhost:44350/api/player/${playerName.value}`)
    // console.log(resp);
    data.value.balance = resp.data.player.Balance;
    store.setBalance(resp.data.player.Balance);
    store.setIsUserLoaded();
    store.setUser(resp.data.player.Name);
    alert(`Se ha cargado exitosamente el saldo de ${playerName.value}`)
  } catch (error) {
    if(error.response.data.Message) {
      alert(error.response.data.Message)
      return
    }
    // console.log(error);
    alert(error.message)
  } finally {
    isSearching.value = false
    playerName.value = ""
  }
  
}

const handleSubmit = () => {
  const { balance, bet } = data.value;
  // provide("message", "hello form home");
  if (bet > balance) {
    alert("Apuesta no puede ser mayor al saldo");
    return;
  }

  if(!bet || !balance) {
    alert("Saldo o apuesta debe definirse")
    return
  }

  store.setBalance(balance - bet);
  store.setBet(bet);

  router.push("/game");
};
</script>

<template>
  <main
    class="w-full h-screen bg-[url('./assets/roulette-bg.jpg')] bg-no-repeat bg-cover bg-bottom flex flex-col justify-center items-center px-8 py-4"
  >
    <section class="h-[15%] w-full flex justify-end items-start">
      <div>
        <div class="min-w-[300px] px-6 rounded-md">
        <label
          for="search"
          class="mb-2 text-sm font-medium text-gray-900 sr-only dark:text-white"
          >Search</label
        >
        <div class="relative">
          <div
            class="absolute inset-y-0 left-0 flex items-center pl-3 pointer-events-none"
          >
            <svg
              class="w-4 h-4 text-gray-500 dark:text-gray-400"
              aria-hidden="true"
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 20 20"
            >
              <path
                stroke="currentColor"
                stroke-linecap="round"
                stroke-linejoin="round"
                stroke-width="2"
                d="m19 19-4-4m0-7A7 7 0 1 1 1 8a7 7 0 0 1 14 0Z"
              />
            </svg>
          </div>
          <input
            type="search"
            id="search"
            class="block w-80 p-4 pl-10 text-sm  rounded-lg 
            border-gray-600 placeholder-gray-400 text-gray-700 focus:ring-blue-500
             focus:border-blue-500"
            placeholder="lion45"
            v-model="playerName"
            required
          />
          <button
            @click="handleSearch"
            class="text-white absolute right-2.5 bottom-2.5 bg-blue-700 hover:bg-blue-800 
            focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-4 
            py-2 dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800"
          >
            {{ isSearching ? "Buscando en la db..." : "Recuperar saldo" }}
          </button>
        </div>
      </div>
      </div>
    </section>
    <section class="h-[85%] grid place-content-center">
      <form
        @submit.prevent="handleSubmit"
        class="flex flex-col gap-4 min-w-[350px]"
      >
        <div>
          <label for="balance" class="block mb-1 text-md font-medium text-white"
            >Saldo</label
          >
          <input
            type="number"
            id="balance"
            class="bg-gray-200 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5"
            placeholder="5000"
            v-model="data.balance"
          />
        </div>
        <div>
          <label for="balance" class="block mb-1 text-md font-medium text-white"
            >Apuesta</label
          >
          <input
            type="number"
            id="balance"
            class="bg-gray-200 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5"
            placeholder="200"
            v-model="data.bet"
          />
        </div>
        <button
          type="submit"
          class="text-white font-bold bg-blue-600 hover:bg-blue-700 rounded-md px-4 py-2"
        >
          Ir a la ruleta
        </button>
      </form>
    </section>
    <!-- <Modal /> -->
  </main>
</template>
