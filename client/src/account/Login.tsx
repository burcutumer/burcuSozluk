import { FieldValues, useForm } from "react-hook-form";
import FormText from "../components/FormText";
import { useNavigate } from "react-router-dom";
import agent from "../api/agent";
import { useState } from "react";
import { User } from "../models/user";
import { useStoreContext } from "../context/StoreContext";

interface IFormValues {
    nickName: string,
    email: string,
    password: string,
    passwordm: string
}

function Login() {
    const { register, handleSubmit, formState: { errors } } = useForm<IFormValues>({
        mode: 'all'
    })
    const navigate = useNavigate();
    const {setUserLoading} = useStoreContext();
    const [isError, setIsError] = useState<boolean>(false);
    const [isLoading, setIsLoading] = useState<boolean>(false);

    function submitForm(data: FieldValues) {
        agent.Account.login(data)
        .then((res) => {
            localStorage.setItem("jwt", res.data.jwtToken);
            setUserLoading(true)
            navigate("/")
        }).catch(_ => {
            localStorage.removeItem("jwt")
            setIsError(true)
        })
        .finally(() => setIsLoading(false))
    }

    return (
        <>
            <div className="w-[25%]">
                <div>
                    <h5 className="py-8 text-lg font-extrabold">Giris</h5>
                </div>
                <div>
                    <form onSubmit={handleSubmit(submitForm)}>
                        {isError && <p className="mt-2 mb-4 text-pink-600 text-sm">
                            {"hatali kullanici ya da sifre, ama hangisi soylemem"}
                        </p>}
                        <label className="block">
                            <FormText inputType={"text"} title="email" register={{ ...register("email", { required: 'kullanici adi bos olamaz' }) }} />
                            {errors?.email && <p className="mt-2 mb-4 text-pink-600 text-sm">
                                {`${errors.email.message}`}
                            </p>}
                        </label>
                        <label className="block">
                            <FormText inputType="password" title="sifre" register={{ ...register("password", { required: 'sifre bos olamaz' }) }} />
                            {errors.password && <p className="mt-2 mb-4 text-pink-600 text-sm">{`${errors.password.message}`}
                            </p>}
                            <input type="checkbox" name="status" />
                            <label className="px-2  text-sm whitespace-nowrap">unutma bunlari sorcam sana</label>
                        </label>


                        <button disabled={isLoading} type="submit" className="block rounded-none mt-4 py-2 px-24 bg-green-600 text-sm text-white whitespace-nowrap">giris yapmaya cabala</button>
                    </form>
                </div>
                <div className="py-4 flex flex-col">
                    <h5 className="py-4 text-lg font-extrabold">giremeyis</h5>
                    <a href="#" className="py-2 text-sm">sifremi unuttum</a>
                    <a href="#" className="text-sm">kayitli kullanici olunasi</a>
                </div>
            </div>
        </>
    )
}

export default Login;