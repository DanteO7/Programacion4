import { create } from "zustand";
import { persist } from "zustand/middleware";

const handler = (set) => ({
  isAuthenticated: false,
  user: null,

  login: ({ user, token }) => set({ isAuthenticated: true, token, user }),
  logout: () => set({ isAuthenticated: false, token: null, user: null }),
});

export const useAuthStore = create(persist(handler, { name: "auth-store" }));
