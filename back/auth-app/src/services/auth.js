const { VITE_API_URL: apiUrl } = import.meta.env;
export const signIn = async (credenials) => {
  const res = await fetch(apiUrl + "/auth/login", {
    method: "POST",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(credenials),
  });

  const data = await res.json();
  return data;
};

export const signUp = async (user) => {
  const res = await fetch(apiUrl + "/auth/register", {
    method: "POST",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(user),
  });

  const data = await res.json();
  return data;
};

export const checkAuth = async () => {
  const res = await fetch(apiUrl + "/auth/health", {
    credentials: "include",
  });

  return !(res.status == 401 || res.status == 403);
};

export const getUsers = async () => {
  const res = await fetch(apiUrl + "/auth/users", {
    credentials: "include",
  });

  const data = await res.json();
  return data;
};

export const signOut = async () => {
  await fetch(apiUrl + "/auth/users", {
    method: "POST",
    credentials: "include",
  });
};
