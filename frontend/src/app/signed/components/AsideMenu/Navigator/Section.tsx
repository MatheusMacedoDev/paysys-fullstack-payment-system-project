import { IconProp } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { ReactNode } from 'react';

interface SectionProps {
    sectionTitle: string;
    sectionIcon: IconProp;
    children: ReactNode;
}

export default function Section({
    sectionTitle,
    sectionIcon,
    children
}: SectionProps) {
    return (
        <section className="text-green-300 space-y-7">
            <div className="flex items-center gap-2">
                <FontAwesomeIcon className="text-2xl" icon={sectionIcon} />
                <span className="font-extrabold text-xl">{sectionTitle}</span>
            </div>
            <div className="ml-5 space-y-5">{children}</div>
        </section>
    );
}
