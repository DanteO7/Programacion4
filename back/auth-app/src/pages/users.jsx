import { useQuery } from "@tanstack/react-query";
import { getUsers } from "../services/auth";
import { useAuthStore } from "../store/auth-store";
import { Redirect } from "wouter";

export default function Users() {
  const { isAuthenticated, user } = useAuthStore();
  const { data: users } = useQuery({
    queryKey: ["users"],
    queryFn: getUsers,
  });

  if (!isAuthenticated || !user?.roles.includes("Admin")) {
    return <Redirect href="/" />;
  }

  console.log(users);

  return users?.map((u) => <p key={u.id}>{u.userName}</p>);
}
