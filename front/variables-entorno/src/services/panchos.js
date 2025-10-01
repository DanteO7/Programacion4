const { VITE_API } = import.meta.env;

export const getAllPanchos = async () => {
  const res = await fetch(VITE_API + "/panchos");
  const data = await res.json();
  return data;
};

export const createPancho = async (pancho) => {
  const res = await fetch(VITE_API + "/panchos", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(pancho),
  });
  const data = await res.json();
  return data;
};
