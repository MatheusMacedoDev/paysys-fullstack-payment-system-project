import { ReactNode } from 'react';

interface TitleProps {
    children: ReactNode;
}

export default function Title({ children }: TitleProps) {
    return <h1 className="font-black text-4xl text-green-300">{children}</h1>;
}
