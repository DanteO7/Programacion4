import * as z from "zod";

export const userValidation = z
  .object({
    username: z
      .string("Campo obligatorio")
      .nonempty("Campo obligatorio")
      .min(5, "Minimo 5 caracteres"),
    email: z.email("Campo obligatorio").nonoptional("Campo obligatorio"),
    password: z
      .string()
      .regex(
        /^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@%+-]).{8,}$/,
        "Caracteres necesarios 8: A-Z, a-z, @%+-"
      ),
    confirmPassword: z
      .string()
      .regex(
        /^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@%+-]).{8,}$/,
        "Caracteres necesarios 8: A-Z, a-z, @%+-"
      ),
  })
  .refine((data) => data.password === data.confirmPassword, {
    message: "Las contraseñas no coinciden",
    path: ["confirmPassword"],
  });
