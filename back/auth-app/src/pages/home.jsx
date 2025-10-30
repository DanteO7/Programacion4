import { useAuthStore } from "../store/auth-store";
import SignIn from "../components/sign-in";
import { signOut } from "../services/auth";

export default function Home() {
  const { isAuthenticated, user, logout } = useAuthStore();

  if (isAuthenticated) {
    return (
      <div className="flex flex-col gap-4 mx-auto mt-10 w-md">
        <h1 className="text-center">Welcome {user.userName}</h1>
        <Button
          onClick={() => {
            signOut().then(logout);
          }}
          color="alternative"
        >
          Logout
        </Button>
      </div>
    );
  }

  return <SignIn></SignIn>;
}
