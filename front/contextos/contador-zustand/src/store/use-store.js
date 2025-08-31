import { create } from "zustand";
import { persist } from "zustand/middleware";

const handler = (set) => ({
  contador: 0,
  aumentar: () => set((state) => ({ contador: state.contador + 1 })),
  decrementar: () => set((state) => ({ contador: state.contador - 1 })),
  resetear: () => set(() => ({ contador: 0 })),
});

export const useCountStore = create(persist(handler, { name: "counter" }));

export const useUsersStore = create((set) => ({
  usuarios: [],
  cargarUsuarios: async () => {
    try {
      const res = await fetch("http://jsonplaceholder.typicode.com/users");
      const datos = await res.json();

      set({ usuarios: datos });
    } catch (error) {
      console.error(`No se pudo acceder a los usuarios - error: ${error}`);
    }
  },
}));
