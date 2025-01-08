interface Props {
    register: any;
    inputType: 'email' | 'text' | 'password';
    title: string;
}

function FormText({ inputType, title, register }: Props) {

    return (
        <>
            <span className="block text-sm mt-4 mb-2 font-medium text-slate-700">{title}</span>
            <input type={inputType} {...register} className="peer mt-1 block w-full px-3 py-2 bg-white border border-slate-300 text-sm  invalid:bg-blue-100" />
        </>
    )
}
export default FormText;