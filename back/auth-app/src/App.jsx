import { Route, Router } from "wouter";
import Home from "./pages/home";
import Users from "./pages/users";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { ReactQueryDevtools } from "@tanstack/react-query-devtools";
import { useEffect } from "react";
import { checkAuth, signOut } from "./services/auth";
import { useAuthStore } from "./store/auth-store";

const queryClient = new QueryClient();

export default function App() {
  const logout = useAuthStore((s) => s.logout);
  useEffect(() => {
    checkAuth().then((ok) => {
      if (!ok) {
        logout();
        signOut();
      }
    });
  }, []);

  return (
    <>
      <QueryClientProvider client={queryClient}>
        <ReactQueryDevtools />
        <Router>
          <Route path="/">
            <Home />
          </Route>
          <Route path="/users">
            <Users />
          </Route>
        </Router>
      </QueryClientProvider>
    </>
  );
}
