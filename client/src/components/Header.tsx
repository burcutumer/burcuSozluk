import { useStoreContext } from "../context/StoreContext"

export default function Header() {

    const { user,signOut } = useStoreContext();
    const handleSignOut = () => {
        signOut();
    }

    return (
        <header className="fixed top-0 left-0 right-0 px-28 pt-4 h-[8rem] flex flex-col bg-white  border-t-green-600 border-b-gray-400 border-b border-t-8">
            <div className="h-full flex flex-row">
                <section className="w-full h-full flex flex-row items-center">
                    <div className="h-full w-[40%]">
                        <span className="text-2xl font-bold text-green-600">O </span>
                        <span className="text-2xl font-bold text-gray-800">burcu</span>
                        <span className="text-2xl font-bold text-green-600">sozluk</span>
                    </div>
                    <div className="bg-slate-50 border-solid border-2 rounded-lg border-green-600 w-[60%] flex flex-row items-center">
                        <input
                            className=" h-6 w-full rounded-lg"
                            type="text"
                            placeholder="search"
                        />
                        <button className="h-6 bg-green-600 px-2">
                            🔍
                        </button>
                    </div>
                </section>
                {user ? (
                    <section className="w-[90%] h-full flex flex-row-reverse items-center">
                         <ul className="px-3">
                            <a onClick={handleSignOut} href="/" >Logout</a>
                        </ul>
                        <ul className="px-3">
                            <a href="/">{user.nickName}</a>
                        </ul>
                    </section>) : (
                    <section className="w-[90%] h-full flex flex-row-reverse items-center">
                        <ul className="px-3">
                            <a href="/register">kayit ol</a>
                        </ul>
                        <ul className="px-3">
                            <a href="/login">giris</a>
                        </ul>
                    </section>)}

            </div>
            <div className="h-full grid grid-cols-11 grid-flow-row w-full">
                <div className="grid grid-flow-col col-start-1 col-end-10 gap-7 items-center justify-evenly pt-2">
                    <ul className="hover:border-b-4 border-green-600 h-full min-w-[10rem] text-center">
                        <li><a href="#">gundem</a></li>
                    </ul>
                    <ul className="hover:border-b-4 border-green-600 h-full w-full">
                        <li><a href="debe">debe</a></li>
                    </ul>
                    <ul className="hover:border-b-4 border-green-600 h-full w-full">
                        <li><a href="sorunsallar">sorunsallar</a></li>
                    </ul>
                    <ul className="hover:border-b-4 border-green-600 h-full w-full">
                        <li><a href="spor">#spor</a></li>
                    </ul>
                    <ul className="hover:border-b-4 border-green-600 h-full w-full">
                        <li><a href="iliskiler">#iliskiler</a></li>
                    </ul>
                    <ul className="hover:border-b-4 border-green-600 h-full w-full">
                        <li><a href="siyaset">#siyaset</a></li>
                    </ul>
                    <ul className="hover:border-b-4 border-green-600 h-full w-full">
                        <li><a href="#">...</a></li>
                    </ul>
                </div>
                <div className="grid grid-flow-col gap-5 col-start-10 col-end-12 items-center justify-evenly">
                    <ul>O pena</ul>
                    <ul>O eksi seyler</ul>
                </div>
            </div>
        </header>
    )
}