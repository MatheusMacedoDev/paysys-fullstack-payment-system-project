import { ReactNode } from 'react';

interface HomeContainerProps {
    children: ReactNode;
}

export default function HomeContainer({ children }: HomeContainerProps) {
    return (
        <div className="px-8 py-28 lg:p-28 xl:px-48 space-y-40 lg:space-y-60">
            {children}
        </div>
    );
}
