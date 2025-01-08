import { PropsWithChildren, createContext, useContext, useState } from "react";
import { User } from "../models/user";

interface StoreContextValue {
    user: User | null;
    setUser: (user:User|null) => void;
    signOut: () => void;
    userLoading: boolean
    setUserLoading: (state: boolean) => void;
}
export const StoreContext = createContext<StoreContextValue | undefined>(undefined)

export function useStoreContext() {
    const context = useContext(StoreContext);
    if (context === undefined) {
        throw Error('Opps-we dont seem to be inside the provider');
    }
    return context;
}

export function StoreProvider({children}: PropsWithChildren<any>) {

    const[user,setUser] = useState<User|null>(null);
    const [userLoading, setUserLoading] = useState(false)

    const signOut = () => {
        localStorage.removeItem('jwt');
        setUser(null);
    };
    return (
        <StoreContext.Provider value={{user, setUser, signOut, userLoading, setUserLoading}}>
            {children}
        </StoreContext.Provider>
    )
}