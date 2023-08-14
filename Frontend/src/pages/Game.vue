<script setup>
import { ref } from "vue";
import axios from "axios";
import { useRouter } from "vue-router";
import { useBalanceStore } from "../stores/Balance";

const chosenOption = ref("");
const isGameOK = ref(false);
const store = useBalanceStore();
const gameData = ref({});
const playerName = ref("");

const router = useRouter();

if (!store.bet || !store.balance) {
  router.push("/");
}

const rouletteNumbers = [
  { value: 3, color: "rojo" },
  { value: 6, color: "negro" },
  { value: 9, color: "rojo" },
  { value: 12, color: "rojo" },
  { value: 15, color: "negro" },
  { value: 18, color: "rojo" },
  { value: 21, color: "rojo" },
  { value: 24, color: "negro" },
  { value: 27, color: "rojo" },
  { value: 30, color: "rojo" },
  { value: 33, color: "negro" },
  { value: 36, color: "rojo" },
  { value: 2, color: "negro" },
  { value: 5, color: "rojo" },
  { value: 8, color: "negro" },
  { value: 11, color: "negro" },
  { value: 14, color: "rojo" },
  { value: 17, color: "negro" },
  { value: 20, color: "negro" },
  { value: 23, color: "rojo" },
  { value: 26, color: "negro" },
  { value: 29, color: "negro" },
  { value: 32, color: "rojo" },
  { value: 35, color: "negro" },
  { value: 1, color: "rojo" },
  { value: 4, color: "negro" },
  { value: 7, color: "rojo" },
  { value: 10, color: "negro" },
  { value: 13, color: "negro" },
  { value: 16, color: "rojo" },
  { value: 19, color: "rojo" },
  { value: 22, color: "negro" },
  { value: 25, color: "rojo" },
  { value: 28, color: "negro" },
  { value: 31, color: "negro" },
  { value: 34, color: "rojo" },
];

const otherOptions = [
  { value: "Rojo par" },
  { value: "Rojo impar" },
  { value: "Negro par" },
  { value: "Negro impar" },
];

const colors = [
  { value: "rojo", name: "Rojo" },
  { value: "negro", name: "Negro" },
];

const handleExit = () => {
  isGameOK.value = false;
  router.push("/");
};

const handleSave = async () => {
  if (store.isUserLoaded) {
    try {
      store.setBalance(store.balance + gameData.value.betUpdate);
      const resp = await axios.post("https:localhost:44350/api/player", {
        Name: store.user,
        Balance: store.balance,
      });
    } catch (error) {
      if (error.response.data.Message) {
        alert(error.response.data.Message);
        return;
      }
      alert(error.message);
    } finally {
      router.push("/");
    }
  } else {
    if (!playerName.value.trim()) {
      alert("El nombre del jugador debe definirse");
      return;
    }

    try {
      store.setBalance(store.balance + gameData.value.betUpdate);
      const resp = await axios.post("https:localhost:44350/api/player", {
        Name: playerName.value,
        Balance: store.balance,
      });
    } catch (error) {
      if (error.response.data.Message) {
      alert(error.response.data.Message);
      return;
    }
      alert(error.message);
    } finally {
      router.push("/")
    }
  }
};

const handleSubmit = async () => {
  console.log(chosenOption.value);
  try {
    const resp = await axios.post("https:localhost:44350/api/game", {
      pick: chosenOption.value,
      bet: store.bet,
    });

    // console.log(resp.data);

    isGameOK.value = true;
    gameData.value = resp.data;
  } catch (error) {
    if (error.response.data.Message) {
      alert(error.response.data.Message);
      return;
    }
    alert(error.message);
  }
};
</script>

<template>
  <main
    class="w-full h-screen bg-[url('./assets/green-bg.jpg')] bg-no-repeat bg-cover flex flex-col gap-6 justify-center items-center"
  >
    <div class="text-white text-center flex flex-col gap-4">
      <h1 class="text-4xl font-bold">
        Saldo: $<span>{{ store.balance }}</span>
      </h1>
      <h2 class="text-2xl font-bold">
        Apuesta: $<span>{{ store.bet }}</span>
      </h2>
      <h3 class="text-md" v-if="chosenOption === ''">
        Aún no has elegido para apostar
      </h3>
      <h3 class="text-md" v-else>Tu elección: {{ chosenOption }}</h3>
    </div>

    <div>
      <div class="flex items-start">
        <div class="flex justify-end relative translate-y-20 m-0 p-0">
          <input
            class="hidden"
            type="radio"
            id="0"
            name="selection"
            @change="() => (chosenOption = 0)"
          />
          <label
            class="selection block border border-white h-full text-center text-3xl font-bold text-white rotate-90 py-2 px-4"
            for="0"
          >
            0
          </label>
        </div>
        <div>
          <div class="grid grid-cols-12 border border-white">
            <div
              class="border border-white w-14 py-3"
              v-for="number in rouletteNumbers"
            >
              <input
                class="hidden"
                type="radio"
                :id="number.value"
                name="selection"
                @change="() => (chosenOption = number.value)"
              />
              <label
                class="selection number block h-full text-center text-3xl font-bold text-white -rotate-90 py-1"
                :for="number.value"
                :data-color="number.color"
              >
                {{ number.value }}
              </label>
            </div>
          </div>
          <div class="flex justify-center">
            <div
              class="border border-white border-t-0"
              v-for="option of otherOptions"
            >
              <input
                class="hidden"
                type="radio"
                :id="option.value"
                name="selection"
                @change="() => (chosenOption = option.value)"
              />
              <label
                class="selection block h-full text-center text-2xl font-bold text-white py-1 px-[9.5px]"
                :for="option.value"
              >
                {{ option.value }}
              </label>
            </div>
          </div>
        </div>
        <div class="flex flex-col relative translate-y-12">
          <div
            class="border p-3 border-white border-l-0 grid place-content-center"
            v-for="color in colors"
          >
            <input
              class="hidden"
              type="radio"
              :id="color.value"
              name="selection"
              @change="() => (chosenOption = color.name)"
            />
            <label
              class="selection block w-8 h-8 text-center text-2xl font-bold text-white -rotate-45"
              :for="color.value"
              :data-color="color.value"
            >
            </label>
          </div>
        </div>
      </div>
    </div>
    <button
      @click="handleSubmit"
      class="text-white font-bold bg-blue-600 hover:bg-blue-700 rounded-md px-9 py-3"
    >
      Jugar
    </button>
  </main>
  <div
    v-if="isGameOK"
    class="absolute z-20 bg-black/80 inset-0 grid place-content-center"
  >
    <div
      class="bg-gray-100 rounded-md h-[500px] w-[800px] p-8 text-center flex flex-col items-center justify-between"
    >
      <h1 class="text-4xl font-bold">
        {{ gameData.isAWin ? "Ganaste!" : "Perdiste :(" }}
      </h1>
      <h2 class="result text-7xl mt-4" :data-result="gameData.result.color">
        {{ gameData.result.value }}
      </h2>
      <h3 class="text-2xl">Apuesta ganada: ${{ gameData.betUpdate }}</h3>
      <div class="flex gap-20 justify-between">
        <button
          v-if="store.isUserLoaded"
          @click="handleSave"
          class="py-4 px-8 bg-green-600 text-white text-lg rounded-md"
        >
          Guardar
        </button>
        <div v-else class="min-w-[300px] px-6 rounded-md">
          <label
            for="search"
            class="mb-2 text-sm font-medium text-gray-900 sr-only dark:text-white"
            >Search</label
          >
          <div class="relative">
            <div
              class="absolute inset-y-0 left-0 flex items-center pl-3 pointer-events-none"
            ></div>
            <input
              type="search"
              id="search"
              class="block w-80 p-4 pl-10 text-sm rounded-lg bg-gray-300 border-gray-600 placeholder-gray-400 text-gray-700 focus:ring-blue-500 focus:border-blue-500"
              placeholder="lion45"
              v-model="playerName"
              required
            />
            <button
              @click="handleSave"
              class="text-white absolute right-2.5 bottom-2.5 bg-green-700 hover:bg-green-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-4 py-2"
            >
              Guardar jugador
            </button>
          </div>
        </div>
        <button
          @click="handleExit"
          class="py-4 px-8 bg-red-600 text-white text-lg rounded-md"
        >
          Salir
        </button>
      </div>
    </div>
  </div>
</template>
