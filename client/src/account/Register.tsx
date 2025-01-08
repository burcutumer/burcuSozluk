import { SubmitHandler, useForm } from "react-hook-form";
import { faExclamation } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import FormText from "../components/FormText";
import { useRef } from "react";
import agent from "../api/agent";
import { useNavigate } from "react-router-dom";
interface IFormValues {
    nickName: string,
    email: string,
    password: string,
    passwordm: string
}
function Register() {
    const { register, handleSubmit, watch, formState: { errors } } = useForm<IFormValues>({
        mode: 'all'
    })
    const navigate = useNavigate();

    const password = useRef({});
    password.current = watch("password", "");

    const onSubmit: SubmitHandler<IFormValues> = (data) => agent.Account.regsiter({...data}).then(_ => navigate("/login"));

    return (
        <>
            <div className="w-[25%]">
                <h5 className="py-8 text-lg font-extrabold">yeni kullanici kaydi</h5>
                <div>
                    <form onSubmit={handleSubmit(onSubmit)}>
                        <label className="block">
                            <FormText inputType={"text"} title="nick" register={{ ...register("nickName", { required: 'Boyle nick olmaz olsun.', }) }} />
                            {errors?.nickName && <p className="mt-2 mb-4 text-pink-600 text-sm">
                                {`${errors.nickName.message}`}
                            </p>}
                        </label>
                        <label className="block">
                            <FormText inputType="email" title="email" register={{
                                ...register("email", {
                                    required: 'Boyle email olmaz olsun.',
                                    pattern: {
                                        value: /^\w+[\w-.]*@\w+((-\w+)|(\w*))\.[a-z]{2,3}$/,
                                        message: 'Boyle email olmaz olsun.'
                                    }
                                })
                            }} />
                            {errors?.email && <p className="mt-2 mb-4 text-pink-600 text-sm">
                                {`${errors.email.message}`}
                            </p>}
                        </label>
                        <div className="flex flex-row mb-6">
                            <a href="/" className="py-1">
                                <FontAwesomeIcon icon={faExclamation} size="xl" style={{ color: "#1d222a" }} />
                            </a>
                            <p className="mx-3 text-sm">hesap guvenliginiz acisindan sifrenizin <span className="font-extrabold">diger sitelerde kullandiginiz sifrelerden farkli olmasini</span> tavsiye ederiz.</p>
                        </div>

                        <label className="block">
                            <FormText inputType="password" title="sifre" register={{
                                ...register('password', {
                                    required: 'Password is required',
                                    pattern: {
                                        value: /(?=^.{6,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$/,
                                        message: 'password does not meet complexity requirements'
                                    }
                                })
                            }} />
                            <p className="text-xs mb-4 mt-1 w-1/3 text-gray-400">sifre en az 8 karakter en az bir buyuk harf en az bir kucuk harf rakam icermelidir</p>
                            <FormText inputType="password" title="sifre (tekrar)" register={{
                                ...register('passwordm', {
                                    validate: value => value === password.current
                                })
                            }} />
                            {errors.passwordm && <p className="mt-2 text-pink-600 text-sm">
                                sifreler tutmuyor.
                            </p>}
                            <p className="text-xs mb-4 mt-1 w-1/3 text-gray-400">sifre en az 8 karakter en az bir buyuk harf en az bir kucuk harf rakam icermelidir</p>
                        </label>
                        <div >
                            <input type="checkbox" name="status" />
                            <label className="px-2  text-sm">burcu sozluk kullanici sozlesmesini okudum ve kabul ediyorum</label>
                        </div>
                        <input type="submit" className="block rounded-none mt-4 py-2 px-24 bg-green-600 text-sm text-white whitespace-nowrap" value={"kayit ol iste boyle"} />
                    </form>
                </div>
            </div>
        </>
    )
}

export default Register;