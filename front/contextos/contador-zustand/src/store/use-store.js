import { create } from "zustand";

const useCountStore = create((set) => ({
  contador: 0,
  aumentar: () => set((state) => ({ contador: state.contador + 1 })),
  decrementar: () => set((state) => ({ contador: state.contador - 1 })),
  resetear: () => set(() => ({ contador: 0 })),
}));

export default useCountStore;
