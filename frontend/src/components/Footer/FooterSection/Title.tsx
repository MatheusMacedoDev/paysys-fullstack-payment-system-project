import { ReactNode } from 'react';

interface TitleProps {
    children: ReactNode;
}

export default function Title({ children }: TitleProps) {
    return <h3 className="font-semibold text-lg text-gray-800">{children}</h3>;
}
