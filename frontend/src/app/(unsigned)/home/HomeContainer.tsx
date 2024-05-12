import { ReactNode } from 'react';

interface HomeContainerProps {
    children: ReactNode;
}

export default function HomeContainer({ children }: HomeContainerProps) {
    return <div className="lg:p-28 xl:px-48 space-y-60">{children}</div>;
}
